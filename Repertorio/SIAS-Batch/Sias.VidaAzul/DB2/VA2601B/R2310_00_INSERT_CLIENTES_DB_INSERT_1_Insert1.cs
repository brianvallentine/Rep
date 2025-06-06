using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
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
            :DCLPESSOA.PESSOA-NOME-PESSOA,
            'F' ,
            :DCLPESSOA-FISICA.CPF,
            '0' ,
            :DCLPESSOA-FISICA.DATA-NASCIMENTO
            :VIND-DATA-NASCIMENTO,
            0,
            NULL,
            NULL,
            NULL,
            NULL,
            :DCLPESSOA-FISICA.SEXO,
            :DCLPESSOA-FISICA.ESTADO-CIVIL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES ({FieldThreatment(this.COD_CLIENTE)}, {FieldThreatment(this.PESSOA_NOME_PESSOA)}, 'F' , {FieldThreatment(this.CPF)}, '0' ,  {FieldThreatment((this.VIND_DATA_NASCIMENTO?.ToInt() == -1 ? null : this.DATA_NASCIMENTO))}, 0, NULL, NULL, NULL, NULL, {FieldThreatment(this.SEXO)}, {FieldThreatment(this.ESTADO_CIVIL)}, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string COD_CLIENTE { get; set; }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string CPF { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string VIND_DATA_NASCIMENTO { get; set; }
        public string SEXO { get; set; }
        public string ESTADO_CIVIL { get; set; }

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