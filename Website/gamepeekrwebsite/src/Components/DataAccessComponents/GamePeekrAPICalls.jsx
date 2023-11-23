import APILink from "../ReusableComponents/Config";
import axios from "axios";



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

  const PostReviewData = async (postData) => {
    try
    {
      await axios.post(`${APILink}/api/Review`, postData);
    } 
    catch (error) 
    {
      throw error;
    };
  }
export {GetById};
export {PostReviewData};
export {GetAll};