using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1 : QueryBasis<R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1>
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
            VALUES (:WHOST-COD-CLIENTE,
            :DCLCLIENTES.NOME-RAZAO,
            :DCLCLIENTES.TIPO-PESSOA,
            :DCLCLIENTES.CGCCPF,
            :DCLCLIENTES.SIT-REGISTRO,
            :DCLCLIENTES.DATA-NASCIMENTO
            :VIND-DATA-NASCIMENTO,
            :DCLCLIENTES.COD-EMPRESA,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :DCLCLIENTES.COD-GRD-GRUPO-CBO
            :VIND-COD-GRD-GRUPO-CBO,
            :DCLCLIENTES.COD-SUBGRUPO-CBO
            :VIND-COD-SUBGRUPO-CBO,
            :DCLCLIENTES.COD-GRUPO-BASE-CBO
            :VIND-COD-GRUPO-BASE-CBO,
            :DCLCLIENTES.COD-SUBGR-BASE-CBO
            :VIND-COD-SUBGR-BASE-CBO
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES ({FieldThreatment(this.WHOST_COD_CLIENTE)}, {FieldThreatment(this.NOME_RAZAO)}, {FieldThreatment(this.TIPO_PESSOA)}, {FieldThreatment(this.CGCCPF)}, {FieldThreatment(this.SIT_REGISTRO)},  {FieldThreatment((this.VIND_DATA_NASCIMENTO?.ToInt() == -1 ? null : this.DATA_NASCIMENTO))}, {FieldThreatment(this.COD_EMPRESA)}, NULL, NULL, NULL, NULL, NULL, NULL,  {FieldThreatment((this.VIND_COD_GRD_GRUPO_CBO?.ToInt() == -1 ? null : this.COD_GRD_GRUPO_CBO))},  {FieldThreatment((this.VIND_COD_SUBGRUPO_CBO?.ToInt() == -1 ? null : this.COD_SUBGRUPO_CBO))},  {FieldThreatment((this.VIND_COD_GRUPO_BASE_CBO?.ToInt() == -1 ? null : this.COD_GRUPO_BASE_CBO))},  {FieldThreatment((this.VIND_COD_SUBGR_BASE_CBO?.ToInt() == -1 ? null : this.COD_SUBGR_BASE_CBO))} )";

            return query;
        }
        public string WHOST_COD_CLIENTE { get; set; }
        public string NOME_RAZAO { get; set; }
        public string TIPO_PESSOA { get; set; }
        public string CGCCPF { get; set; }
        public string SIT_REGISTRO { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string VIND_DATA_NASCIMENTO { get; set; }
        public string COD_EMPRESA { get; set; }
        public string COD_GRD_GRUPO_CBO { get; set; }
        public string VIND_COD_GRD_GRUPO_CBO { get; set; }
        public string COD_SUBGRUPO_CBO { get; set; }
        public string VIND_COD_SUBGRUPO_CBO { get; set; }
        public string COD_GRUPO_BASE_CBO { get; set; }
        public string VIND_COD_GRUPO_BASE_CBO { get; set; }
        public string COD_SUBGR_BASE_CBO { get; set; }
        public string VIND_COD_SUBGR_BASE_CBO { get; set; }

        public static void Execute(R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1 r4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1)
        {
            var ths = r4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4310_10_INSERT_CLIENTES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}