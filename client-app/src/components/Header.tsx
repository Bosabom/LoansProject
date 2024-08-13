import React from "react"
import { Link } from "react-router-dom";

export default function Header(){
    return (
        <nav id="header">
            <span> <Link to="/templates" className="tabs">Templates</Link> </span>
            <span> <Link to="/loanRequests" className="tabs">Loan Requests</Link> </span>
        </nav>
    );
}