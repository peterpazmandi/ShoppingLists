import { useNavigate, Link } from 'react-router-dom'
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { useContext, useState } from 'react';
import { UserContextType } from '../context/types/userContext.type';
import { UserContext } from '../context/authContext';
import { LoginEntity } from '../context/entities/login.entity';

const Login = () => {
    const { isLoading, login } = useContext(UserContext) as UserContextType;
    const navigate = useNavigate();

    const formSchema = yup.object().shape({
        username: yup.string().required('Username is required'),
        password: yup.string().required('Password is required')
    })
    
    const {
        register,
        handleSubmit,
        formState: { errors }
    } = useForm<LoginEntity>({
        resolver: yupResolver(formSchema)
    })

    const onSubmit = async (data: LoginEntity) => {
        login(data).then(result => {
            if (result) {
                navigate('/shoppinglists');
            }
        });
    }
    
    return (
        <div className="d-flex justify-content-center align-items-center">
            <div className='border border-4 border-primary rounded-3 shadow-lg m-5 pt-5 pb-2 w-50'>
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
        </div>
    )
}

export default Login