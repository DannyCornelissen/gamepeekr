import APILink from "../ReusableComponents/Config";
import axios from "axios";
import { auth } from "../../Utils/firebase.utils";

async function GetAll(url) 
{
    try 
    {
       const response = await axios.get(url);
       if (response.status >= 200 && response.status < 300)
      {
        const incomingData = await response.data;
        return incomingData;
      } 
      else 
      {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
    } 
    catch (error) 
    {
      console.error('Error fetching data:', error);
      throw new Error();
    }
}

async function GetById(id) 
{
    try 
    {
      const response = await axios.get(`${APILink}/api/Review/${id}`);
      if (response.status >= 200 && response.status < 300)
      {
        const incomingData = await response.data;
        return incomingData;
      } 
      else 
      {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

    } 
    catch (error) 
    {
      console.error('Error fetching data:', error);
      throw error;
    }
}

  const PostData = async (postData, url) => {
    try {
      const idToken = await auth.currentUser.getIdToken();
  
      const headers = {
        'Authorization': `Bearer ${idToken}`,
        'Content-Type': 'application/json', 
      };
  
      await axios.post(url, postData, { headers });
    } 
    catch (error) 
    {
      throw error;
    };
  }
export {GetById};
export {PostData};
export {GetAll};