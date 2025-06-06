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
    public class M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1 : QueryBasis<M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.CODPRODAZ, B.DTQITBCO
            INTO :PROPAZ-CODPRODAZ, :PROPAZ-DTQITBCO
            FROM SEGUROS.V0RESSARCIAZUL A,
            SEGUROS.V0PROPAZUL B
            WHERE A.NSAS = :MVCOM-NSAS
            AND A.NSL = :MVCOM-NSL1
            AND B.NRPROPAZ = A.NRPROPAZ
            AND B.AGELOTE = A.AGELOTE
            AND B.DTLOTE = A.DTLOTE
            AND B.NRLOTE = A.NRLOTE
            AND B.NRSEQLOTE = A.NRSEQLOTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.CODPRODAZ
							, B.DTQITBCO
											FROM SEGUROS.V0RESSARCIAZUL A
							,
											SEGUROS.V0PROPAZUL B
											WHERE A.NSAS = '{this.MVCOM_NSAS}'
											AND A.NSL = '{this.MVCOM_NSL1}'
											AND B.NRPROPAZ = A.NRPROPAZ
											AND B.AGELOTE = A.AGELOTE
											AND B.DTLOTE = A.DTLOTE
											AND B.NRLOTE = A.NRLOTE
											AND B.NRSEQLOTE = A.NRSEQLOTE
											WITH UR";

            return query;
        }
        public string PROPAZ_CODPRODAZ { get; set; }
        public string PROPAZ_DTQITBCO { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL1 { get; set; }

        public static M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1 Execute(M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1 m_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1)
        {
            var ths = m_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0033_LOCALIZA_RESSARC_DB_SELECT_2_Query1();
            var i = 0;
            dta.PROPAZ_CODPRODAZ = result[i++].Value?.ToString();
            dta.PROPAZ_DTQITBCO = result[i++].Value?.ToString();
            return dta;
        }

    }
}