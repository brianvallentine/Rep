using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1 : QueryBasis<M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CLIENTES
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
            VALUES (:WS-COD-CLI-ATU ,
            :BI0005L-S-NOME-PESSOA ,
            'F' ,
            :BI0005L-S-CPF ,
            '0' ,
            :BI0005L-S-DATA-NASC :VIND-DAT-NAS ,
            0 ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            :BI0005L-S-SEXO ,
            :BI0005L-S-ESTADO-CIVIL ,
            NULL ,
            NULL ,
            NULL ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES ({FieldThreatment(this.WS_COD_CLI_ATU)} , {FieldThreatment(this.BI0005L_S_NOME_PESSOA)} , 'F' , {FieldThreatment(this.BI0005L_S_CPF)} , '0' ,  {FieldThreatment((this.VIND_DAT_NAS?.ToInt() == -1 ? null : this.BI0005L_S_DATA_NASC))} , 0 , NULL , NULL , NULL , NULL , {FieldThreatment(this.BI0005L_S_SEXO)} , {FieldThreatment(this.BI0005L_S_ESTADO_CIVIL)} , NULL , NULL , NULL , NULL )";

            return query;
        }
        public string WS_COD_CLI_ATU { get; set; }
        public string BI0005L_S_NOME_PESSOA { get; set; }
        public string BI0005L_S_CPF { get; set; }
        public string BI0005L_S_DATA_NASC { get; set; }
        public string VIND_DAT_NAS { get; set; }
        public string BI0005L_S_SEXO { get; set; }
        public string BI0005L_S_ESTADO_CIVIL { get; set; }

        public static void Execute(M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1 m_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1)
        {
            var ths = m_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}