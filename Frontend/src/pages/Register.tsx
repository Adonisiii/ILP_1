
import { useState } from "react";
import type { FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { AuthService } from "../services/AuthService";

function Register() {
    const navigate = useNavigate();

    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [address, setAddress] = useState("");
    const [personalNumber, setPersonalNumber] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    async function handleRegister(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
        setError("");
        setLoading(true);

        try {
            await AuthService.Register({
                name,
                surname,
                email,
                password,
                address,
                personalNumber,
                phoneNumber
            });

            alert("Regjistrimi u realizua me sukses!");
            navigate("/");
        } catch (err) {
            if (axios.isAxiosError(err)) {
                if (err.response?.status === 409) {
                    setError("Ky email është i regjistruar.");
                } else if (err.response?.status === 400) {
                    setError("Kontrolloni të dhënat e formularit.");
                } else {
                    setError("Regjistrimi dështoi. Kontrolloni serverin.");
                }
            } else {
                setError("Ndodhi një gabim i papritur.");
            }
        } finally {
            setLoading(false);
        }
    }

    return (
        <div className="login-card register-card">
            <div className="login-title">Regjistrohu</div>

            <form onSubmit={handleRegister} className="login-form">
                <label>Emri *</label>
                <input
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required
                />

                <label>Mbiemri *</label>
                <input
                    value={surname}
                    onChange={(e) => setSurname(e.target.value)}
                    required
                />

                <label>Email *</label>
                <input
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />

                <label>Fjalëkalimi *</label>
                <input
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    minLength={8}
                    required
                />

                <label>Adresa *</label>
                <input
                    value={address}
                    onChange={(e) => setAddress(e.target.value)}
                    required
                />

                <label>Numri personal *</label>
                <input
                    value={personalNumber}
                    onChange={(e) => setPersonalNumber(e.target.value)}
                    required
                />

                <label>Numri i telefonit *</label>
                <input
                    type="tel"
                    value={phoneNumber}
                    onChange={(e) => setPhoneNumber(e.target.value)}
                    required
                />

                {error && (
                    <p role="alert" style={{ color: "red" }}>{error}</p>
                )}

                <button
                    type="submit"
                    className="login-button"
                    disabled={loading}
                >
                    {loading ? "Duke u regjistruar..." : "Regjistrohu"}
                </button>

                <p className="register-text">
                    Keni llogari? <a href="/">Kyçu</a>
                </p>
            </form>
        </div>
    );
}

export default Register;
