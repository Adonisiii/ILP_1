
import { useState } from "react";
import type { FormEvent } from "react";
import { AuthService } from "../services/AuthService";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    async function handleLogin(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
        setError("");
        setLoading(true);

        try {
            const result = await AuthService.Login({
                email: email,
                password: password
            });

            console.log("Login u realizua me sukses!");
            console.log("User ID:", result.userId);
            alert("Jeni kyçur me sukses!");
        } catch (error) {
            console.error("Gabim gjatë Login:", error);
            setError("Kyçja dështoi. Kontrolloni të dhënat ose lidhjen me serverin.");
        } finally {
            setLoading(false);
        }
    }

    return (
        <div className="login-card">
            <div className="login-title">Login</div>
            <form onSubmit={handleLogin} className="login-form">
                <label htmlFor="email">
                    Email<span>*</span>
                </label>
                <input
                    id="email"
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
                <label htmlFor="password">
                    Fjalëkalimi<span>*</span>
                </label>
                <input
                    id="password"
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
                {error && (
                    <p role="alert" style={{ color: "red", fontSize: "13px" }}>
                        {error}
                    </p>
                )}
                <button
                    type="submit"
                    className="login-button"
                    disabled={loading}
                >
                    {loading ? "Duke u kyçur..." : "Hyr"}
                </button>
                <p className="register-text">
                    Nuk keni llogari? <a href="/register">Regjistrohu</a>
                </p>
            </form>
        </div>
    );
}

export default Login;
