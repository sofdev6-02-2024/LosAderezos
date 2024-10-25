import PropTypes from 'prop-types';

function Button ({ children, className, onClick, isSubmit, type, text }) {
  const baseStyles = {
    common:
      'font-bold py-2 px-4 rounded-[8px] transition duration-300'
  };

  const buttonClass = `${baseStyles[type]} ${className}`;

  return (
    <button
      className={`${buttonClass} transition-transform duration-150 active:scale-95 flex flex-row items-center`}
      type={isSubmit ? 'submit' : 'button'}
      onClick={onClick}
    >
      {text ? text : ''}
      {children}
    </button>
  );
};

Button.propTypes = {
  children: PropTypes.node,
  className: PropTypes.string,
  onClick: PropTypes.func,
  isSubmit: PropTypes.bool,
  type: PropTypes.oneOf(['common']),
  text: PropTypes.string,
};

export default Button;
