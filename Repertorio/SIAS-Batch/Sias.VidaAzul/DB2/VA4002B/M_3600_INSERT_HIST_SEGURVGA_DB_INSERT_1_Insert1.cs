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
    public class M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1 : QueryBasis<M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.V0HISTSEGVG
            VALUES
            (:PROPVA-NUM-APOLICE,
            :PROPVA-CODSUBES,
            :WHOST-NUM-ITEM,
            101,
            CURRENT_DATE,
            CURRENT_TIME,
            CURRENT_DATE,
            :SEGURVGA-OCORR-HISTORICO,
            0,
            :PROPVA-DTQITBCO,
            'VA4002B' ,
            NULL,
            1,
            1)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTSEGVG VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.WHOST_NUM_ITEM)}, 101, CURRENT_DATE, CURRENT_TIME, CURRENT_DATE, {FieldThreatment(this.SEGURVGA_OCORR_HISTORICO)}, 0, {FieldThreatment(this.PROPVA_DTQITBCO)}, 'VA4002B' , NULL, 1, 1)";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string WHOST_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string PROPVA_DTQITBCO { get; set; }

        public static void Execute(M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1 m_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1)
        {
            var ths = m_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_3600_INSERT_HIST_SEGURVGA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}