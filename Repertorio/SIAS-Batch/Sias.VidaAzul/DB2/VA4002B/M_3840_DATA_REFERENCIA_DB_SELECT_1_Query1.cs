using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1 : QueryBasis<M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :FATURCON-DATA-REFERENCIA
            FROM SEGUROS.FATURAS_CONTROLE
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPVA-CODSUBES
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.FATURAS_CONTROLE
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPVA_CODSUBES}'";

            return query;
        }
        public string FATURCON_DATA_REFERENCIA { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1 Execute(M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1 m_3840_DATA_REFERENCIA_DB_SELECT_1_Query1)
        {
            var ths = m_3840_DATA_REFERENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3840_DATA_REFERENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.FATURCON_DATA_REFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}