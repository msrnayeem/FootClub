// postcss.config.js
module.exports = {
    plugins: [
      require('autoprefixer')({
        // Specify the desired browser compatibility
        browsers: ['last 2 versions', 'not dead', 'not IE <= 11']
      })
    ]
  }
  