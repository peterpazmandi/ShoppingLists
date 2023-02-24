import { useNavigate } from 'react-router-dom'
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { login } from '../services/shoppingListService'
import { USER } from '../utils/globalConsts';

interface LoginFormData {
    username: string;
    password: string;
}

const Login = () => {
    const navigate = useNavigate();

    const formSchema = yup.object().shape({
        username: yup.string().required('Username is required'),
        password: yup.string().required('Password is required')
    })
    
    const {
        register,
        handleSubmit,
        formState: { errors }
    } = useForm<LoginFormData>({
        resolver: yupResolver(formSchema)
    })

    const onSubmit = async (data: LoginFormData) => {
        login(data).then(response => {
            localStorage.setItem(USER, JSON.stringify(response));
            navigate('/');
        });
    }
    
    return (
        <div className='mt-5 mb-5'>
            <h1>Login</h1>
            <form onSubmit={handleSubmit(onSubmit)}>
                <div className="flex-column mt-5 mb-2">
                    <div className="d-flex justify-content-center">
                        <input
                            className='form-control w-50'
                            type="text" 
                            placeholder="Username"
                            {...register('username')} />
                    </div>
                    <div className="d-flex justify-content-center">
                        <p className="text-danger">{errors.username?.message}</p>
                    </div>
                </div>
                <div className="flex-column mb-5">
                    <div className="d-flex justify-content-center">
                        <input 
                            className='form-control w-50'
                            type="password" 
                            placeholder="Password" 
                            {...register('password')} />
                    </div>
                    <div className="d-flex justify-content-center">
                        <p className="text-danger">{errors.password?.message}</p>
                    </div>
                </div>
                <button
                    disabled={Object.keys(errors).length > 0}
                    className='btn btn-primary'
                    type="submit">Submit</button>
            </form>
        </div>
    )
}

export default Login