export type KnownProblem = {
    title: string,
    subtitle: string,
    errors: Record<string, string[]>,
    traceId: string,
}

export function is_known_problem(response: Response): boolean {
    return response.headers.has("X-IsKnownProblem");
}