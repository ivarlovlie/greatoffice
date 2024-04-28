import type { ISettingsService } from "./abstractions/ISettingsService";

export class SettingService implements ISettingsService {
    static resolve(): ISettingsService {
        return new SettingService();
    }
    get_user_settings(): Promise<void> {
        throw new Error("Method not implemented.");
    }
}