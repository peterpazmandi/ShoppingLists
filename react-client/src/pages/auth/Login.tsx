import { useNavigate, Link } from 'react-router-dom'
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { login } from '../../services/shoppingListService'
import { USER } from '../../utils/globalConsts';
import { useContext, useState } from 'react';
import { UserContextType } from './types/user.type';
import { UserContext } from './authContext';
import { User } from './entities/user.entity';

interface LoginFormData {
    username: string;
    password: string;
}

const Login = () => {
    const { updateCurrentUser } = useContext(UserContext) as UserContextType;
    const [isLoading, setIsLoading] = useState(false);
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
        setIsLoading(true);
        login(data).then(user => {
            setIsLoading(false);
            updateCurrentUser(user);
            navigate('/shoppinglists');
        });
    }
    
    return (
        <div className='border border-4 border-primary rounded-3 shadow-lg m-5 pt-5 pb-2'>
            <h1>Login</h1>
            <form onSubmit={handleSubmit(onSubmit)}>
                <div className="flex-column mt-5 mb-2">
                    <div className="d-flex justify-content-center">
                        <input
                            className='form-control w-75'
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
                            className='form-control w-75'
                            type="password" 
                            placeholder="Password" 
                            {...register('password')} />
                    </div>
                    <div className="d-flex justify-content-center">
                        <p className="text-danger">{errors.password?.message}</p>
                    </div>
                </div>
                <button
                    disabled={ isLoading || Object.keys(errors).length > 0}
                    className='btn btn-primary'
                    type="submit">{ !isLoading ? "Submit" : "Loading..." }</button>
                <div className="flex-column mt-4 mb-3">
                    <Link to="/register">Register</Link>
                </div>
            </form>
        </div>
    )
}

export default Login