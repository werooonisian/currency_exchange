import logo from './logo.svg';
import './App.css';

import {BrowserRouter} from 'react-router-dom';
import React, {useState} from 'react';

function App() {

  var pln;
  var usd;
  const [result, setResult] = useState();

  function HandleClick(e)
{
    e.preventDefault(); 

    fetch("https://localhost:44306/api/home/get_current_rate/")
    .then(response => response.json())
    .then(json =>
        {
            usd = json.mid;
            if(pln>=0)
            {
              setResult(usd * pln);
            }
            else
            {
              setResult('enter correct data')
            }
            console.log(result);
        })
}

  return (
    <BrowserRouter>
      <div className="container">
        <h3 className='m-3 d-flex justify-content-center'>
          Currency Exchange
        </h3>
      </div>



      <div className='mt-5 d-flex justify-content-center'>
                <form>
                    <div className='m-2 d-flex justify-content-center'>
                    <label>PLN:</label>
                    </div>
                    <input
                        type="number"
                        step="0.01"
                        min="0"
                        onChange={e => pln = (e.target.value)}
                    />
                    <div>
                    <label className='m-2 d-flex justify-content-center'>USD:</label>
                
                    <label name="usdLabel" className='m-2 d-flex justify-content-center' >
                        {result}
                    </label>
                    </div>
                    <div className='m-2 d-flex justify-content-center'>
                        <button onClick={HandleClick}>ok</button>
                    </div>
                </form>
            </div>
    </BrowserRouter>
  );
}

export default App;
              