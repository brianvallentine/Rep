using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1652B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            INTO :HISCOBPR-NUM-CERTIFICADO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_INIVIGENCIA = :WHOST-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA = '{this.WHOST_DTINIVIG}'";

            return query;
        }
        public string HISCOBPR_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string WHOST_DTINIVIG { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_NUM_CERTIFICADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}