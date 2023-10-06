import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Homepage from './Components/Home/Homepage';
import Review from './Components/ReviewComponents/Review';

function App() {
  return (
<BrowserRouter>
      <Routes>
        <Route path="/" element={<Homepage />}>
          </Route>
        <Route path="/review/:id" element={<Review />}>
        </Route>
      </Routes>
    </BrowserRouter>

  );
}

export default App;
