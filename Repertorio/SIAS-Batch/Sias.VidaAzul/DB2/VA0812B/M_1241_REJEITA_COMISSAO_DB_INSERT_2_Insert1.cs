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
    public class M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1 : QueryBasis<M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCOMPROPAZ
            VALUES ( :PROPAZ-NRPROPAZ,
            :PROPAZ-AGELOTE,
            :PROPAZ-DTLOTE,
            :PROPAZ-NRLOTE,
            :PROPAZ-NRSEQLOTE,
            'G' ,
            102,
            :COMPROPH-VLCOMISVG,
            :COMPROPH-VLCOMISAP,
            :COMPROPH-VALBASVG,
            :COMPROPH-VALBASAP,
            CURRENT DATE,
            '0' ,
            'VA0812B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCOMPROPAZ VALUES ( {FieldThreatment(this.PROPAZ_NRPROPAZ)}, {FieldThreatment(this.PROPAZ_AGELOTE)}, {FieldThreatment(this.PROPAZ_DTLOTE)}, {FieldThreatment(this.PROPAZ_NRLOTE)}, {FieldThreatment(this.PROPAZ_NRSEQLOTE)}, 'G' , 102, {FieldThreatment(this.COMPROPH_VLCOMISVG)}, {FieldThreatment(this.COMPROPH_VLCOMISAP)}, {FieldThreatment(this.COMPROPH_VALBASVG)}, {FieldThreatment(this.COMPROPH_VALBASAP)}, CURRENT DATE, '0' , 'VA0812B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPAZ_NRPROPAZ { get; set; }
        public string PROPAZ_AGELOTE { get; set; }
        public string PROPAZ_DTLOTE { get; set; }
        public string PROPAZ_NRLOTE { get; set; }
        public string PROPAZ_NRSEQLOTE { get; set; }
        public string COMPROPH_VLCOMISVG { get; set; }
        public string COMPROPH_VLCOMISAP { get; set; }
        public string COMPROPH_VALBASVG { get; set; }
        public string COMPROPH_VALBASAP { get; set; }

        public static void Execute(M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1 m_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1)
        {
            var ths = m_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1241_REJEITA_COMISSAO_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}