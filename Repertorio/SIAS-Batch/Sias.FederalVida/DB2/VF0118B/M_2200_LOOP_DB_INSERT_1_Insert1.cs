using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_2200_LOOP_DB_INSERT_1_Insert1 : QueryBasis<M_2200_LOOP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0BENEFIPROP
            VALUES (:PROPVA-NUM-APOLICE,
            :PROPVA-CODSUBES,
            :PROPVA-FONTE,
            :FONTE-PROPAUTOM,
            :BENEF-NRBENEF,
            :BENEF-NOMBENEF,
            :BENEF-GRAUPAR,
            :BENEF-PCTBENEF,
            'VF0118B' ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0BENEFIPROP VALUES ({FieldThreatment(this.PROPVA_NUM_APOLICE)}, {FieldThreatment(this.PROPVA_CODSUBES)}, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.FONTE_PROPAUTOM)}, {FieldThreatment(this.BENEF_NRBENEF)}, {FieldThreatment(this.BENEF_NOMBENEF)}, {FieldThreatment(this.BENEF_GRAUPAR)}, {FieldThreatment(this.BENEF_PCTBENEF)}, 'VF0118B' , NULL)";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string FONTE_PROPAUTOM { get; set; }
        public string BENEF_NRBENEF { get; set; }
        public string BENEF_NOMBENEF { get; set; }
        public string BENEF_GRAUPAR { get; set; }
        public string BENEF_PCTBENEF { get; set; }

        public static void Execute(M_2200_LOOP_DB_INSERT_1_Insert1 m_2200_LOOP_DB_INSERT_1_Insert1)
        {
            var ths = m_2200_LOOP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2200_LOOP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}