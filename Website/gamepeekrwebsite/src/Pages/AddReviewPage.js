import React from 'react';
import AddReviewComponent from '../Components/ReviewComponents/AddReviewComponent';
import Menu from '../Components/ReusableComponents/Menu';
import Head from '../Components/ReusableComponents/Head'



const AddReviewPage = () => {
  return (
    <html>
      <Head title='Home' description='this is the homepage'></Head>
      <body>
        <div>
            <div>
                <Menu/>
            </div>
          <div>
            <main>
              <AddReviewComponent />
            </main>
          </div>
        </div>
      </body>

    </html>


  );
};

export default AddReviewPage;