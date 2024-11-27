import { Field } from 'formik';
import PropTypes from 'prop-types';

function InputField ({ id, label, name, placeholder, type, isCorrect, isDisabled, icon, iconPosition = 'right', onIconClick, isRequired }) {
  return (
    <label htmlFor={id} className='block mb-2'>
      <span className='text-[14px] text-neutral-950 font-roboto font-regular'>
        {label}
        {isRequired && <span className='text-red-700'> *</span>}
      </span>
      <div>
        {icon && iconPosition === 'left' && (
          <span
            className="absolute inset-y-0 left-0 flex items-center pl-3 cursor-pointer"
            onClick={onIconClick}
          >
            {icon}
          </span>
        )}
        <Field
          id={id}
          name={name}
          type={type}
          className={`bg-white w-full h-12 font-roboto rounded-[10px] focus:ring-blue-800 focus:border-blue-800
            block p-2.5 px-5 py-3 outline-none transition duration-150 
            ${icon && iconPosition === 'left' ? 'pl-10' : ''}
            ${icon && iconPosition === 'right' ? 'pr-10' : ''}
            ${isCorrect ? 'border-2 border-neutral-200' : 'border-2 border-red-500'}`}
          placeholder={placeholder}
          disabled={isDisabled}
          required={isRequired}
        />
        {icon && iconPosition === 'right' && (
          <span
            className="absolute inset-y-0 right-0 flex items-center pr-3 cursor-pointer"
            onClick={onIconClick}
          >
            {icon}
          </span>
        )}
      </div>
    </label>
  );
}

InputField.propTypes = {
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    placeholder: PropTypes.string.isRequired,
    type: PropTypes.string,
    isCorrect: PropTypes.bool,
    isDisabled: PropTypes.bool,
    icon: PropTypes.element,
    iconPosition: PropTypes.oneOf(['left', 'right']),
    onIconClick: PropTypes.func,
    isRequired: PropTypes.bool,
};

export default InputField;
