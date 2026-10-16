import axios from "axios";
import type { LoginRequest } from "../interfaces/LoginRequest";
import type { RegisterRequest } from "../interfaces/RegisterRequest";
import type { AuthResponse } from "../interfaces/AuthResponse";

export class AuthService {
    private static BaseUrl = "/api/Auth";

    public static async Login(model: LoginRequest): Promise<AuthResponse> {
        const response = await axios.post<AuthResponse>(
            `${this.BaseUrl}/login`,
            model
        );
        return response.data;
    }

    public static async Register(model: RegisterRequest): Promise<AuthResponse> {
        const response = await axios.post<AuthResponse>(
            `${this.BaseUrl}/register`,
            model
        );
        return response.data;
    }
}