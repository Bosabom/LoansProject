import React from "react"
import Button from "../components/UI/Button";
import { Link } from "react-router-dom";
import Input from "../components/UI/Input";

export function TemplatesPage(){
    return(
        <>
        <Button href="/addTemplate">New Template</Button>
        <Button href="/addLoanRequest">Create Loan Request</Button>
        <Button>Delete</Button>

        <Input type="search" label="" id="template-search" />

        </>
        //TODO: add table for templates and pagination
    );
}