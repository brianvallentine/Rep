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
    public class M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1 : QueryBasis<M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VLCOMISVG),0),
            VALUE(SUM(VLCOMISAP),0),
            VALUE(MAX(VALBASVG),0),
            VALUE(MAX(VALBASAP),0)
            INTO :COMPROPH-VLCOMISVG,
            :COMPROPH-VLCOMISAP,
            :COMPROPH-VALBASVG,
            :COMPROPH-VALBASAP
            FROM SEGUROS.V0HISTCOMPROPAZ
            WHERE NRPROPAZ = :PROPAZ-NRPROPAZ
            AND AGELOTE = :PROPAZ-AGELOTE
            AND DTLOTE = :PROPAZ-DTLOTE
            AND NRLOTE = :PROPAZ-NRLOTE
            AND NRSEQLOTE = :PROPAZ-NRSEQLOTE
            AND TIPCOM = 'G'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VLCOMISVG)
							,0)
							,
											VALUE(SUM(VLCOMISAP)
							,0)
							,
											VALUE(MAX(VALBASVG)
							,0)
							,
											VALUE(MAX(VALBASAP)
							,0)
											FROM SEGUROS.V0HISTCOMPROPAZ
											WHERE NRPROPAZ = '{this.PROPAZ_NRPROPAZ}'
											AND AGELOTE = '{this.PROPAZ_AGELOTE}'
											AND DTLOTE = '{this.PROPAZ_DTLOTE}'
											AND NRLOTE = '{this.PROPAZ_NRLOTE}'
											AND NRSEQLOTE = '{this.PROPAZ_NRSEQLOTE}'
											AND TIPCOM = 'G'
											WITH UR";

            return query;
        }
        public string COMPROPH_VLCOMISVG { get; set; }
        public string COMPROPH_VLCOMISAP { get; set; }
        public string COMPROPH_VALBASVG { get; set; }
        public string COMPROPH_VALBASAP { get; set; }
        public string PROPAZ_NRSEQLOTE { get; set; }
        public string PROPAZ_NRPROPAZ { get; set; }
        public string PROPAZ_AGELOTE { get; set; }
        public string PROPAZ_DTLOTE { get; set; }
        public string PROPAZ_NRLOTE { get; set; }

        public static M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1 Execute(M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1 m_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1)
        {
            var ths = m_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1241_REJEITA_COMISSAO_DB_SELECT_2_Query1();
            var i = 0;
            dta.COMPROPH_VLCOMISVG = result[i++].Value?.ToString();
            dta.COMPROPH_VLCOMISAP = result[i++].Value?.ToString();
            dta.COMPROPH_VALBASVG = result[i++].Value?.ToString();
            dta.COMPROPH_VALBASAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}