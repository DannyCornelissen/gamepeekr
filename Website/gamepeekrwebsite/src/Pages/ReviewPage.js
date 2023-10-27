import React, { Component } from 'react';
import ReviewRetrieverById from '../Components/ReviewComponents/ReviewRetrieverById';
import Menu from '../Components/ReusableComponents/Menu';
import Head from '../Components/ReusableComponents/Head';




const ReviewPage = () => {
  return (
    <html>
      <Head title='Review' description='This is the review page where you can read the current review'></Head>
      <body>
        <div>
          <div>
            <Menu />
          </div>
          <div>
            <main>
              <ReviewRetrieverById />
            </main>
          </div>
        </div>
      </body>

    </html>


  );
};

export default ReviewPage;
