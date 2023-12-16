import React from 'react';
import './App.css';
import Search from '../Search/Search';

function App() {
  return (
    <div className="App">
      <h2>Tech Test!</h2>
      <p>Welcome to my solution to this tech test. I've kept the UI as simple as possible in places, except where I've noted in the readme files or commentary.</p>
      <p>Please ignore the extremely basic styling on this page. It felt like overkill to import bootstrap or tailwind just to style 2 components.</p>
      <Search />
    </div>
  );
}

export default App;
