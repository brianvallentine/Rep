using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1 : QueryBasis<R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COMIS_SICOB
            VALUES (:V0SICB-CODEMP ,
            :V0SICB-FONTE ,
            :V0SICB-NRRCAP ,
            :V0SICB-NUMBIL ,
            :V0SICB-AGECOBR ,
            :V0SICB-NRMATRVEN ,
            :V0SICB-AGECTAVEN ,
            :V0SICB-OPRCTAVEN ,
            :V0SICB-NUMCTAVEN ,
            :V0SICB-DIGCTAVEN ,
            :V0SICB-VLCOMIS ,
            :V0SICB-DTCREDITO ,
            :V0SICB-DTQITBCO ,
            :V0SICB-DTMOVTO ,
            :V0SICB-VLRCAP ,
            :V0SICB-SITUACAO ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMIS_SICOB VALUES ({FieldThreatment(this.V0SICB_CODEMP)} , {FieldThreatment(this.V0SICB_FONTE)} , {FieldThreatment(this.V0SICB_NRRCAP)} , {FieldThreatment(this.V0SICB_NUMBIL)} , {FieldThreatment(this.V0SICB_AGECOBR)} , {FieldThreatment(this.V0SICB_NRMATRVEN)} , {FieldThreatment(this.V0SICB_AGECTAVEN)} , {FieldThreatment(this.V0SICB_OPRCTAVEN)} , {FieldThreatment(this.V0SICB_NUMCTAVEN)} , {FieldThreatment(this.V0SICB_DIGCTAVEN)} , {FieldThreatment(this.V0SICB_VLCOMIS)} , {FieldThreatment(this.V0SICB_DTCREDITO)} , {FieldThreatment(this.V0SICB_DTQITBCO)} , {FieldThreatment(this.V0SICB_DTMOVTO)} , {FieldThreatment(this.V0SICB_VLRCAP)} , {FieldThreatment(this.V0SICB_SITUACAO)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0SICB_CODEMP { get; set; }
        public string V0SICB_FONTE { get; set; }
        public string V0SICB_NRRCAP { get; set; }
        public string V0SICB_NUMBIL { get; set; }
        public string V0SICB_AGECOBR { get; set; }
        public string V0SICB_NRMATRVEN { get; set; }
        public string V0SICB_AGECTAVEN { get; set; }
        public string V0SICB_OPRCTAVEN { get; set; }
        public string V0SICB_NUMCTAVEN { get; set; }
        public string V0SICB_DIGCTAVEN { get; set; }
        public string V0SICB_VLCOMIS { get; set; }
        public string V0SICB_DTCREDITO { get; set; }
        public string V0SICB_DTQITBCO { get; set; }
        public string V0SICB_DTMOVTO { get; set; }
        public string V0SICB_VLRCAP { get; set; }
        public string V0SICB_SITUACAO { get; set; }

        public static void Execute(R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1 r8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1)
        {
            var ths = r8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8850_00_INSERT_V0COMISICOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}