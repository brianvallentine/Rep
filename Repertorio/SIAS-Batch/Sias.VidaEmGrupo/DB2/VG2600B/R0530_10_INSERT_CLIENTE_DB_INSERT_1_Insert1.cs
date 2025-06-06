using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1 : QueryBasis<R0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CLIENTES
            ( COD_CLIENTE
            , NOME_RAZAO
            , TIPO_PESSOA
            , CGCCPF
            , SIT_REGISTRO
            , DATA_NASCIMENTO
            , COD_EMPRESA
            , COD_PORTE_EMP
            , COD_NATUREZA_ATIV
            , COD_RAMO_ATIVIDADE
            , COD_ATIVIDADE
            , IDE_SEXO
            , ESTADO_CIVIL
            , COD_GRD_GRUPO_CBO
            , COD_SUBGRUPO_CBO
            , COD_GRUPO_BASE_CBO
            , COD_SUBGR_BASE_CBO )
            VALUES( :CLIENTES-COD-CLIENTE -- COD_CLIENTE
            , :CLIENTES-NOME-RAZAO -- NOME_RAZAO
            , :CLIENTES-TIPO-PESSOA -- TIPO_PESSOA
            , :CLIENTES-CGCCPF -- CGCCPF
            , '0' -- SIT_REGISTRO
            , NULL -- DATA_NASCIMENTO
            , NULL -- COD_EMPRESA
            , :CLIENTES-COD-PORTE-EMP -- COD_PORTE_EMP
            INDICATOR :VN-COD-PORTE-EMP
            , NULL -- COD_NATUREZA_ATIV
            , NULL -- COD_RAMO_ATIVIDADE
            , NULL -- COD_ATIVIDADE
            , NULL -- IDE_SEXO
            , NULL -- ESTADO_CIVIL
            , NULL -- COD_GRD_GRUPO_CBO
            , NULL -- COD_SUBGRUPO_CBO
            , NULL -- COD_GRUPO_BASE_CBO
            , NULL -- COD_SUBGR_BASE_CBO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES ( COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO , COD_EMPRESA , COD_PORTE_EMP , COD_NATUREZA_ATIV , COD_RAMO_ATIVIDADE , COD_ATIVIDADE , IDE_SEXO , ESTADO_CIVIL , COD_GRD_GRUPO_CBO , COD_SUBGRUPO_CBO , COD_GRUPO_BASE_CBO , COD_SUBGR_BASE_CBO ) VALUES( {FieldThreatment(this.CLIENTES_COD_CLIENTE)} -- COD_CLIENTE , {FieldThreatment(this.CLIENTES_NOME_RAZAO)} -- NOME_RAZAO , {FieldThreatment(this.CLIENTES_TIPO_PESSOA)} -- TIPO_PESSOA , {FieldThreatment(this.CLIENTES_CGCCPF)} -- CGCCPF , '0' -- SIT_REGISTRO , NULL -- DATA_NASCIMENTO , NULL -- COD_EMPRESA , {FieldThreatment(this.CLIENTES_COD_PORTE_EMP)} -- COD_PORTE_EMP INDICATOR {FieldThreatment(this.VN_COD_PORTE_EMP)} , NULL -- COD_NATUREZA_ATIV , NULL -- COD_RAMO_ATIVIDADE , NULL -- COD_ATIVIDADE , NULL -- IDE_SEXO , NULL -- ESTADO_CIVIL , NULL -- COD_GRD_GRUPO_CBO , NULL -- COD_SUBGRUPO_CBO , NULL -- COD_GRUPO_BASE_CBO , NULL -- COD_SUBGR_BASE_CBO )";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_COD_PORTE_EMP { get; set; }
        public string VN_COD_PORTE_EMP { get; set; }

        public static void Execute(R0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1 r0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1)
        {
            var ths = r0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0530_10_INSERT_CLIENTE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}