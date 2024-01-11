# Use an official Node runtime as a parent image
FROM node:20.6.0

# Set the working directory to /app
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install app dependencies
RUN npm install

# Copy the current directory contents into the container at /app
COPY . .

# Build the React app
RUN npm run build


# Expose port 80 to the outside world
EXPOSE 8080

# Command to run your application
CMD ["npm", "start"]