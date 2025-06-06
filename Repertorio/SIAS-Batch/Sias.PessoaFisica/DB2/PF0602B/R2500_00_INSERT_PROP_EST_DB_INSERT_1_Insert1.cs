using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1 : QueryBasis<R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROP_ESTIPULANTE
            VALUES (:PROPESTI-COD-FONTE ,
            :PROPESTI-NUM-PROPOSTA,
            :PROPESTI-COD-PRODUTO ,
            :PROPESTI-COD-CCT ,
            :PROPESTI-COD-FROTA ,
            :PROPESTI-NUM-APOLICE ,
            :PROPESTI-NUM-BILHETE ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROP_ESTIPULANTE VALUES ({FieldThreatment(this.PROPESTI_COD_FONTE)} , {FieldThreatment(this.PROPESTI_NUM_PROPOSTA)}, {FieldThreatment(this.PROPESTI_COD_PRODUTO)} , {FieldThreatment(this.PROPESTI_COD_CCT)} , {FieldThreatment(this.PROPESTI_COD_FROTA)} , {FieldThreatment(this.PROPESTI_NUM_APOLICE)} , {FieldThreatment(this.PROPESTI_NUM_BILHETE)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPESTI_COD_FONTE { get; set; }
        public string PROPESTI_NUM_PROPOSTA { get; set; }
        public string PROPESTI_COD_PRODUTO { get; set; }
        public string PROPESTI_COD_CCT { get; set; }
        public string PROPESTI_COD_FROTA { get; set; }
        public string PROPESTI_NUM_APOLICE { get; set; }
        public string PROPESTI_NUM_BILHETE { get; set; }

        public static void Execute(R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1 r2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1)
        {
            var ths = r2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_INSERT_PROP_EST_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}