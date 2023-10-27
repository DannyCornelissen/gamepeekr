import React from 'react';
import ReviewRetriever from '../Components/HomeComponents/ReviewRetriever';
import Menu from '../Components/ReusableComponents/Menu';
import Head from '../Components/ReusableComponents/Head'



const HomePage = () => {
  return (
    <html>
      <Head title='Home' description='this is the homepage'></Head>
      <body>
        <div>
          <div>
            <Menu />
          </div>
          <div>
            <header>
              <h1>Reviews</h1>
            </header>
            <main>
              <ReviewRetriever />
            </main>
          </div>
        </div>
      </body>

    </html>


  );
};

export default HomePage;
