import React from 'react';
import './App.css';
import Header from './components/Header';
import { Route, Routes } from 'react-router-dom';
import {TemplatesPage} from './pages/TemplatesPage';
import {LoanRequestsPage} from './pages/LoanRequestsPage';
import NewTemplatePage from './pages/NewTemplatePage';
import NewLoanRequestPage from './pages/NewLoanRequestPage';

function App() {
  return (
       <>
        <Header/>
          <Routes>
            <Route path = "/" element = { <TemplatesPage/> }></Route>
            <Route path = "/templates" element = { <TemplatesPage/> }></Route>
            <Route path = "/loanRequests" element = { <LoanRequestsPage/> }></Route>
            <Route path = "/addTemplate" element = { <NewTemplatePage/> } ></Route>
            <Route path = "/addLoanRequest" element = { <NewLoanRequestPage/> } ></Route>
          </Routes>
      </>
  );
}

export default App;
