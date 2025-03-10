import { useEffect, useState } from 'react';
import { food } from './types/food';

function FoodList() {
  const [foods, setFoods] = useState<food[]>([]);

  useEffect(() => {
    const fetchFood = async () => {
      const response = await fetch('https://localhost:5000/MarriottFood');
      const data = await response.json();
      setFoods(data);
    };
    fetchFood();
  }, []);

  return (
    <>
      <h1>Marriott Food</h1>
      <table>
        <thead>
          <tr>
            <th>Event Name</th>
            <th>Vendor</th>
            <th>Rating</th>
          </tr>
        </thead>
        <tbody>
          {foods.map((food) => (
            <tr key={food.foodid}>
              <td>{food.eventName}</td>
              <td>{food.vendor}</td>
              <td>{food.foodRating}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default FoodList;
