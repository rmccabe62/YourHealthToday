import React, { useState } from 'react';
import { Button, TextField, Grid, Container, Typography } from '@mui/material';
import { saveAs } from 'file-saver';
import './App.css';

function App() {
  // State variables to store form input values and arrival/departure times
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [major, setMajor] = useState('');
  const [arrivalTime, setArrivalTime] = useState('');
  const [departureTime, setDepartureTime] = useState('');
  const [usersData, setUsersData] = useState([]);

  // Function to handle "In" button click
  const handleInButtonClick = () => {
    const currentTime = new Date().toLocaleTimeString();
    setArrivalTime(currentTime);
  };

  // Function to handle "Out" button click
  const handleOutButtonClick = () => {
    const currentTime = new Date().toLocaleTimeString();
    setDepartureTime(currentTime);
  };

  // Function to handle "Save Data" button click
  const handleSaveButtonClick = () => {
    //Handle saving data to usersData array here
    const userData = {
      firstName: '', //Replaces with actual first name from state
      lastName: '', //Replaces with actual last name from state
      major: '', //Replaces with actual major from state
      arrivalTime: '', //Replaces with actual arrival time from state
      departureTime: '', //Replaces with actual departime from state
    };

    setUsersData([...usersData, userData]);

    //Code for saving individual user data as text file
    const data = `Student Name: ${firstName} ${lastName}\nMajor: ${major}\nTime In: ${arrivalTime}\nTime Out: ${departureTime}`;
    const blob = new Blob([data], { type: 'text/plain;charset=utf-8' });
    saveAs(blob, 'lab_tracker_data.txt');
  };

  const handleSaveAllButtonClick = () => {
    //Code for generating and saving all users data as text file
    const formattedData = generateTextFile(usersData);
    const blob = new Blob([formattedData], { type: 'text/plain;charset=utf-8' });
    saveAs(blob, 'all_users_data.txt');
  };

  const generateTextFile = (data) => {
    //Format the data as text
    return data
      .map((user, index) => {
        return `User ${index + 1}:\nFirst Name: ${user.firstName}\nLast Name: ${user.lastName}\nMajor: ${user.major}
        \nTime In: ${user.arrivalTime}\nTime Out: ${user.departureTime}\n\n`;
      })

      .join('');
  };

  // JSX for the UI of the Lab Tracker app
  return (
    <div
      style={{
        background: `url(${process.env.PUBLIC_URL}/computer_lab.jpg)`,
        backgroundSize: 'cover',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '100vh',
      }}
    >
      <Container maxWidth="sm" style={{ backgroundColor: 'rgba(255, 255, 255, 0.9)', padding: '20px' }}>
        {/* Headings */}
        <Typography variant="h1" style={{ textAlign: 'center' }} sx={{ color: '#007bff', fontSize: '2.5rem', fontWeight: 'bold' }}>Lab Tracker</Typography>
        <Typography variant="h3" style={{ textAlign: 'center' }} sx={{ color: '#28a745', fontSize: '1.5rem' }}>Enter your information and click the save button</Typography>
        <Typography variant="h3" style={{ textAlign: 'center' }} sx={{ color: '#28a745', fontSize: '1.5rem' }}>Click In when arriving and Out when leaving the lab</Typography>


        {/* Form fields */}
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <Typography variant="h5" textAlign={'center'}>Student Name</Typography>
          </Grid>
          <Grid item xs={6}>
            <TextField
              label="First Name"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
              fullWidth
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              label="Last Name"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              fullWidth
            />
          </Grid>
          <Grid item xs={12}>
            <Typography variant="h5" textAlign={'center'}>Major</Typography>
            <TextField label="Enter your major" value={major} onChange={(e) => setMajor(e.target.value)} fullWidth />
          </Grid>

          {/* "In" and "Out" buttons */}
          <Grid item xs={6}>
            <Button variant="contained" onClick={handleInButtonClick} fullWidth>
              In
            </Button>
            {/* Display arrival time if available */}
            {arrivalTime && <Typography>Arrived: {arrivalTime}</Typography>}
          </Grid>
          <Grid item xs={6}>
            <Button variant="contained" onClick={handleOutButtonClick} fullWidth>
              Out
            </Button>
            {/* Display departure time if available */}
            {departureTime && <Typography>Left: {departureTime}</Typography>}
          </Grid>

          {/* Save Data button */}
          <Grid item xs={12}>
            <Button variant="contained" onClick={handleSaveButtonClick} fullWidth>
              Save Data
            </Button>
            <Button variant="contained" onClick={handleSaveAllButtonClick} fullWidth>
              Save All Users Data
            </Button>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
}

export default App;

