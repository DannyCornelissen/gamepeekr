import React from 'react';
import ReviewRetriever from './ReviewRetriever';
import Menu from '../ReusableComponents/Menu';
import Head from '../ReusableComponents/Head'



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
