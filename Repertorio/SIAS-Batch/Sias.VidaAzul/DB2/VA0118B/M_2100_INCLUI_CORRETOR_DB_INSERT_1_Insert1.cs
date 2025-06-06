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
    public class M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1 : QueryBasis<M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0APOLCORRET
            VALUES (0109700000024,
            :APCORR-RAMO,
            0,
            17256,
            :PROPVA-CODSUBES,
            :APCORR-DTINIVIG,
            '9999-12-31' ,
            100.00,
            5.00,
            '1' ,
            '1' ,
            0,
            CURRENT TIMESTAMP,
            'VA0118B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCORRET VALUES (0109700000024, {FieldThreatment(this.APCORR_RAMO)}, 0, 17256, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.APCORR_DTINIVIG)}, '9999-12-31' , 100.00, 5.00, '1' , '1' , 0, CURRENT TIMESTAMP, 'VA0118B' )";

            return query;
        }
        public string APCORR_RAMO { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string APCORR_DTINIVIG { get; set; }

        public static void Execute(M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1 m_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1)
        {
            var ths = m_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}