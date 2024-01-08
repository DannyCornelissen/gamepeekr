import React from 'react';
import { Helmet, HelmetProvider } from 'react-helmet-async';

function Head({ title, description }) {
  return (
    <HelmetProvider>
    <Helmet>
      <meta charSet="UTF-8" />
      <meta name="viewport" content="width=device-width, initial-scale=1.0" />
      <title>{title}</title>
      <meta name="description" content={description} />
    </Helmet>
    </HelmetProvider>

  );
}

export default Head;
