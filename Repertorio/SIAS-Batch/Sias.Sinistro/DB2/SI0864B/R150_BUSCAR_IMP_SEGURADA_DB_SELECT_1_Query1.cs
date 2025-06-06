using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0864B
{
    public class R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1 : QueryBasis<R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEG
            INTO :LOTISG01-IMP-SEG
            FROM SEGUROS.LOTIMPSEG01
            WHERE COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL
            AND NUM_APOLICE = :SINILT01-NUM-APOLICE
            AND COD_COBERTURA = :SINILT01-COD-COBERTURA
            AND DTINIVIG <= :SINILT01-DTINIVIG
            AND DTTERVIG >= :SINILT01-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEG
											FROM SEGUROS.LOTIMPSEG01
											WHERE COD_LOT_FENAL = '{this.SINILT01_COD_LOT_FENAL}'
											AND NUM_APOLICE = '{this.SINILT01_NUM_APOLICE}'
											AND COD_COBERTURA = '{this.SINILT01_COD_COBERTURA}'
											AND DTINIVIG <= '{this.SINILT01_DTINIVIG}'
											AND DTTERVIG >= '{this.SINILT01_DTINIVIG}'";

            return query;
        }
        public string LOTISG01_IMP_SEG { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_COD_COBERTURA { get; set; }
        public string SINILT01_NUM_APOLICE { get; set; }
        public string SINILT01_DTINIVIG { get; set; }

        public static R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1 Execute(R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1 r150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1)
        {
            var ths = r150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTISG01_IMP_SEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}