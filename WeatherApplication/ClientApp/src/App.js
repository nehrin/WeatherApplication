import React from "react";
import { useForm } from "react-hook-form";

import "./styles.css";


function App() {
    const {
        register,
        handleSubmit,
        formState: { errors }
    } = useForm();
    const [state, setState] = React.useState({ forecast: "not set yet", loading: true });

    const renderForecast = () => {
        return state.forecast === "OutOfLimit" ? <div>Too many request made. Please Try later.</div> : <div>Forecast is {state.forecast}</div>;
    };

    let contents = state.loading
        ? <div><em>Ready to fetch forcast</em></div> : renderForecast(state.forecast);

    const onSubmit = async (d) => {
        return fetch('weather/location/' + d.city, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then((response) => {
            response.text().then(resData => {
                if(resData != null) setState({ forecast: resData, loading: false });
            })
        })
        .catch((error) => {
            console.error("ERROR: ", error);
        })
    };

    console.log(errors);

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <h1>Weather Forcast</h1>
            <label htmlFor="city">Enter City in "City,ShortCountry" format:</label>
            <input {...register("city")} placeholder="London,uk" />
            <label>{contents}</label>
            <input type="submit" />
            <div style={{ color: "red" }}>
                {Object.keys(errors).length > 0 &&
                    "Server error."}
            </div>
        </form>
    );
}

export default App;

