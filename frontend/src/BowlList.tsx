import { useEffect, useState } from 'react';
import { bowler } from './types/bowler';

function BowlList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  useEffect(() => {
    const fetchBowler = async () => {
      const response = await fetch('https://localhost:5000/BowlingLeague');
      const data = await response.json();
      setBowlers(data);
    };
    fetchBowler();
  }, []);

  return (
    <>
      <h1>Bolwer List</h1>
      <table>
        <thead>
          <tr>
            <th>Last Name</th>
            <th>First Name</th>
            <th>Middle Init</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip Code</th>
            <th>Phone #</th>
            <th>Team ID</th>
            <th>Team Name</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowlers) => (
            <tr key={bowlers.bowlerId}>
              <td>{bowlers.bowlerLastName}</td>
              <td>{bowlers.bowlerFirstName}</td>
              <td>{bowlers.bowlerMiddleInit}</td>
              <td>{bowlers.bowlerAddress}</td>
              <td>{bowlers.bowlerCity}</td>
              <td>{bowlers.bowlerState}</td>
              <td>{bowlers.bowlerZip}</td>
              <td>{bowlers.bowlerPhoneNumber}</td>
              <td>{bowlers.teamId}</td>
              <td>{bowlers.teamName}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlList;
