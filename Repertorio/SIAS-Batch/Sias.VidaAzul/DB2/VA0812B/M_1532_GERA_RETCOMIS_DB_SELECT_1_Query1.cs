using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1 : QueryBasis<M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_LANCAMENTO
            INTO :MVCOM-DATA-MOV
            FROM SEGUROS.V0FITASASSE
            WHERE COD_CONVENIO = :WHOST-CODCONV
            AND NSAS = :MVCOM-NSAS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_LANCAMENTO
											FROM SEGUROS.V0FITASASSE
											WHERE COD_CONVENIO = '{this.WHOST_CODCONV}'
											AND NSAS = '{this.MVCOM_NSAS}'
											WITH UR";

            return query;
        }
        public string MVCOM_DATA_MOV { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string MVCOM_NSAS { get; set; }

        public static M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1 Execute(M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1 m_1532_GERA_RETCOMIS_DB_SELECT_1_Query1)
        {
            var ths = m_1532_GERA_RETCOMIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1532_GERA_RETCOMIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.MVCOM_DATA_MOV = result[i++].Value?.ToString();
            return dta;
        }

    }
}