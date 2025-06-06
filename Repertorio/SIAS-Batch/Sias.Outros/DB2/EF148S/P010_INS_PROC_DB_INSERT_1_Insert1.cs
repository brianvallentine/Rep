using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.EF148S
{
    public class P010_INS_PROC_DB_INSERT_1_Insert1 : QueryBasis<P010_INS_PROC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.EF_PROD_ACESSORIO
            (NUM_CONTRATO_APOL
            , COD_PRODUTO
            , COD_COBERTURA
            , DTH_INI_VIGENCIA
            , NUM_RAMO_CONTABIL
            , COD_PRODUTO_ACESS
            , COD_COBERTURA_ACESS
            , NUM_APOLICE
            , DTH_FIM_VIGENCIA)
            VALUES (
            :EF148-NUM-CONTRATO-APOL ,
            :EF148-COD-PRODUTO ,
            :EF148-COD-COBERTURA ,
            :EF148-DTH-INI-VIGENCIA ,
            :EF148-NUM-RAMO-CONTABIL ,
            :EF148-COD-PRODUTO-ACESS ,
            :EF148-COD-COBERTURA-ACESS ,
            :EF148-NUM-APOLICE ,
            :EF148-DTH-FIM-VIGENCIA
            :WS-DTH-FIM-VIGENCIA-NULL)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.EF_PROD_ACESSORIO (NUM_CONTRATO_APOL , COD_PRODUTO , COD_COBERTURA , DTH_INI_VIGENCIA , NUM_RAMO_CONTABIL , COD_PRODUTO_ACESS , COD_COBERTURA_ACESS , NUM_APOLICE , DTH_FIM_VIGENCIA) VALUES ( {FieldThreatment(this.EF148_NUM_CONTRATO_APOL)} , {FieldThreatment(this.EF148_COD_PRODUTO)} , {FieldThreatment(this.EF148_COD_COBERTURA)} , {FieldThreatment(this.EF148_DTH_INI_VIGENCIA)} , {FieldThreatment(this.EF148_NUM_RAMO_CONTABIL)} , {FieldThreatment(this.EF148_COD_PRODUTO_ACESS)} , {FieldThreatment(this.EF148_COD_COBERTURA_ACESS)} , {FieldThreatment(this.EF148_NUM_APOLICE)} ,  {FieldThreatment((this.WS_DTH_FIM_VIGENCIA_NULL?.ToInt() == -1 ? null : this.EF148_DTH_FIM_VIGENCIA))})";

            return query;
        }
        public string EF148_NUM_CONTRATO_APOL { get; set; }
        public string EF148_COD_PRODUTO { get; set; }
        public string EF148_COD_COBERTURA { get; set; }
        public string EF148_DTH_INI_VIGENCIA { get; set; }
        public string EF148_NUM_RAMO_CONTABIL { get; set; }
        public string EF148_COD_PRODUTO_ACESS { get; set; }
        public string EF148_COD_COBERTURA_ACESS { get; set; }
        public string EF148_NUM_APOLICE { get; set; }
        public string EF148_DTH_FIM_VIGENCIA { get; set; }
        public string WS_DTH_FIM_VIGENCIA_NULL { get; set; }

        public static void Execute(P010_INS_PROC_DB_INSERT_1_Insert1 p010_INS_PROC_DB_INSERT_1_Insert1)
        {
            var ths = p010_INS_PROC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P010_INS_PROC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}