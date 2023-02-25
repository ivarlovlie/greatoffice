import { browser, dev } from "$app/environment";
import { env } from '$env/dynamic/private';
import { StorageKeys } from "$configuration";
import pino, { type Logger, type LoggerOptions } from "pino";
import { createStream } from "pino-seq";
import type { SeqConfig } from "pino-seq";

function get_pino_logger(): Logger {
    const config = {
        name: "greatoffice-app",
        level: LogLevel.current().as_string(),
        customLevels: {
            "INFO": LogLevel.INFO,
            "WARNING": LogLevel.WARNING,
            "ERROR": LogLevel.ERROR,
            "DEBUG": LogLevel.DEBUG,
            "SILENT": LogLevel.SILENT,
        }
    } as LoggerOptions;

    const seq = {
        config: {
            apiKey: browser ? env.SEQ_API_KEY : "",
            serverUrl: browser ? env.SEQ_SERVER_URL : ""
        } as SeqConfig,
        streams: [{
            level: LogLevel.to_string(LogLevel.DEBUG),
        }],
        enabled: () => (
            !browser
            && !dev
            && seq.config.apiKey.length > 0
            && seq.config.serverUrl.length > 0
        )
    };

    return seq.enabled() ? pino(config, createStream(seq.config)) : pino(config);
}

type LogLevelString = "DEBUG" | "INFO" | "WARNING" | "ERROR" | "SILENT";

export const LogLevel = {
    DEBUG: 0,
    INFO: 1,
    WARNING: 2,
    ERROR: 3,
    SILENT: 4,
    current(): { as_string: Function, as_number: Function } {
        const logLevelString = (browser ? window.sessionStorage.getItem(StorageKeys.logLevel) : env.LOG_LEVEL) as LogLevelString;
        return {
            as_number(): number {
                return LogLevel.to_number_or_default(logLevelString, LogLevel.INFO)
            },
            as_string(): LogLevelString {
                return logLevelString.length > 3 ? logLevelString : LogLevel.to_string(LogLevel.INFO);
            }
        }
    },
    to_string(levelInt: number): LogLevelString {
        switch (levelInt) {
            case 0:
                return "DEBUG";
            case 1:
                return "INFO";
            case 2:
                return "WARNING";
            case 3:
                return "ERROR";
            case 4:
                return "SILENT";
            default:
                throw new Error("Unknown LogLevel number " + levelInt);
        }
    },
    to_number_or_default(levelString?: string | null, defaultValue?: number): number {
        if (!levelString && defaultValue) return defaultValue;
        else if (!levelString && !defaultValue) throw new Error("levelString was empty, and no default value was specified");
        switch (levelString?.toUpperCase()) {
            case "DEBUG":
                return 0;
            case "INFO":
                return 1;
            case "WARNING":
                return 2;
            case "ERROR":
                return 3;
            case "SILENT":
                return 4;
            default:
                if (!defaultValue) throw new Error("Unknown LogLevel string " + levelString + ", and no defaultValue");
                else return defaultValue;
        }
    },
};

export function log_warning(message: string, ...additional: any[]): void {
    if (LogLevel.current().as_number() <= LogLevel.WARNING) {
        get_pino_logger().warn(message, additional);
    }
}

export function log_debug(message: string, ...additional: any[]): void {
    if (LogLevel.current().as_number() <= LogLevel.DEBUG) {
        get_pino_logger().debug(message, additional);
    }
}

export function log_info(message: string, ...additional: any[]): void {
    if (LogLevel.current().as_number() <= LogLevel.INFO) {
        get_pino_logger().info(message, additional);
    }
}

export function log_error(message: any, ...additional: any[]): void {
    if (LogLevel.current().as_number() <= LogLevel.ERROR) {
        get_pino_logger().error(message, additional);
    }
}