import React from "react"
import Button from "../components/UI/Button";
import Input from "../components/UI/Input";

export function LoanRequestsPage(){
    return (
        <>
        <br></br>
        <Button href="/editLoanRequest">Edit</Button>
        <Button href="/deleteLoanRequest">Cancel</Button>

        <Input type="search" label="" id="loan-requests-search" />

        </>
    );
}