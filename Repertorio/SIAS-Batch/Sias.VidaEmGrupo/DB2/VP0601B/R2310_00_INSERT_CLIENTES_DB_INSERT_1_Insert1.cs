using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1 : QueryBasis<R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.CLIENTES
            (COD_CLIENTE,
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
            VALUES (:DCLCLIENTES.COD-CLIENTE,
            :PESSOJUR-NOME-FANTASIA,
            'J' ,
            :PESSOJUR-CGC,
            '0' ,
            :DCLCLIENTES.DATA-NASCIMENTO,
            0,
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
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES ({FieldThreatment(this.COD_CLIENTE)}, {FieldThreatment(this.PESSOJUR_NOME_FANTASIA)}, 'J' , {FieldThreatment(this.PESSOJUR_CGC)}, '0' , {FieldThreatment(this.DATA_NASCIMENTO)}, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string COD_CLIENTE { get; set; }
        public string PESSOJUR_NOME_FANTASIA { get; set; }
        public string PESSOJUR_CGC { get; set; }
        public string DATA_NASCIMENTO { get; set; }

        public static void Execute(R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1 r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1)
        {
            var ths = r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}