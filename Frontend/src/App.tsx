
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Register from "./pages/Register";
import Login from "./pages/Login";
import "./App.css";
function App() {
    return (
        <BrowserRouter>
            <div className="app-container">
                <header className="header">
                    <div className="header-content">
                        <div className="logo-placeholder">ATK</div>
                        <div className="header-text">
                            <strong>Administrata Tatimore e Kosovës</strong>
                            <strong>Poreska Administracija Kosova</strong>
                            <strong>Tax Administration of Kosovo</strong>
                        </div>
                    </div>
                </header>
                <nav className="navbar">
                    <div className="nav-content">
                        <a href="/register">Register</a>
                        <a href="/">Login</a>
                    </div>
                </nav>
                <main className="main-content">
                    <Routes>
                        <Route path="/" element={<Login />} />
                        <Route path="/register" element={<Register />} />
                    </Routes>
                </main>
                <footer className="footer">
                    <div className="footer-content">
                        <span>Këndi i Rrugëve Dëshmorët e Kombit dhe Bill Klinton, 10 000 Prishtinë</span>
                        <a href="mailto:info@atk-ks.org">info@atk-ks.org</a>
                        <span>© 2026 Administrata Tatimore e Kosovës (ATK)</span>
                    </div>
                </footer>
            </div>
        </BrowserRouter>
    );
}
export default App;
