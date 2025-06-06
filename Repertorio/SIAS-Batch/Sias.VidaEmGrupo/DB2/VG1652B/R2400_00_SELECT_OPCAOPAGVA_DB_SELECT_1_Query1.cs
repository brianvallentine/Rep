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
    public class R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DIA_DEBITO
            INTO :OPCPAGVI-DIA-DEBITO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_INIVIGENCIA <= :WHOST-DTINIVIG
            AND DATA_TERVIGENCIA >= :WHOST-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DIA_DEBITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA <= '{this.WHOST_DTINIVIG}'
											AND DATA_TERVIGENCIA >= '{this.WHOST_DTINIVIG}'";

            return query;
        }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string WHOST_DTINIVIG { get; set; }

        public static R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 Execute(R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 r2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}