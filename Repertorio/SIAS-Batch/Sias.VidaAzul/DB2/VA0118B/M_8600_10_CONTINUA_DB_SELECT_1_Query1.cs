using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8600_10_CONTINUA_DB_SELECT_1_Query1 : QueryBasis<M_8600_10_CONTINUA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_PARCELA_DESC
            INTO :DESCON-PERC
            FROM SEGUROS.VG_PARCELAS_DESCON
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPVA-CODSUBES
            AND NUM_PARCELA_DESC = 1
            AND DT_INIVIG_PARCDESC <= :DESCON-DTINIVIG
            AND DT_TERVIG_PARCDESC >= :DESCON-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_PARCELA_DESC
											FROM SEGUROS.VG_PARCELAS_DESCON
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPVA_CODSUBES}'
											AND NUM_PARCELA_DESC = 1
											AND DT_INIVIG_PARCDESC <= '{this.DESCON_DTINIVIG}'
											AND DT_TERVIG_PARCDESC >= '{this.DESCON_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string DESCON_PERC { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string DESCON_DTINIVIG { get; set; }

        public static M_8600_10_CONTINUA_DB_SELECT_1_Query1 Execute(M_8600_10_CONTINUA_DB_SELECT_1_Query1 m_8600_10_CONTINUA_DB_SELECT_1_Query1)
        {
            var ths = m_8600_10_CONTINUA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8600_10_CONTINUA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8600_10_CONTINUA_DB_SELECT_1_Query1();
            var i = 0;
            dta.DESCON_PERC = result[i++].Value?.ToString();
            return dta;
        }

    }
}