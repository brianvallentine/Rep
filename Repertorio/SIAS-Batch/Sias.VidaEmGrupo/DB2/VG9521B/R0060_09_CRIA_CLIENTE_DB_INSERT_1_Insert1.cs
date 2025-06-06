using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1 : QueryBasis<R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO
            SEGUROS.CLIENTES
            ( COD_CLIENTE,
            NOME_RAZAO,
            TIPO_PESSOA,
            CGCCPF,
            SIT_REGISTRO,
            DATA_NASCIMENTO,
            COD_EMPRESA,
            COD_PORTE_EMP,
            COD_NATUREZA_ATIV,
            COD_RAMO_ATIVIDADE,
            COD_ATIVIDADE,
            IDE_SEXO,
            ESTADO_CIVIL,
            COD_GRD_GRUPO_CBO,
            COD_SUBGRUPO_CBO,
            COD_GRUPO_BASE_CBO,
            COD_SUBGR_BASE_CBO)
            VALUES (:SEGURVGA-COD-CLIENTE,
            :CLIENTES-NOME-RAZAO,
            'F' ,
            :CLIENTES-CGCCPF,
            '0' ,
            :CLIENTES-DATA-NASCIMENTO,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES ( COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES ({FieldThreatment(this.SEGURVGA_COD_CLIENTE)}, {FieldThreatment(this.CLIENTES_NOME_RAZAO)}, 'F' , {FieldThreatment(this.CLIENTES_CGCCPF)}, '0' , {FieldThreatment(this.CLIENTES_DATA_NASCIMENTO)}, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }

        public static void Execute(R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1 r0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1)
        {
            var ths = r0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0060_09_CRIA_CLIENTE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}