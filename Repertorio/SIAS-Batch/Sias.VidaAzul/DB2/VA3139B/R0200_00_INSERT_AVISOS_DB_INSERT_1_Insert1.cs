using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3139B
{
    public class R0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1 : QueryBasis<R0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0AVISOCRED
            VALUES (:V0AVIS-BCOAVISO ,
            :V0AVIS-AGEAVISO ,
            :V0AVIS-NRAVISO ,
            :V0AVIS-NRSEQ ,
            :V0AVIS-DTMOVTO ,
            :V0AVIS-OPERACAO ,
            :V0AVIS-TIPAVI ,
            :V0AVIS-DTAVISO ,
            :V0AVIS-VLIOCC ,
            :V0AVIS-VLDESPES ,
            :V0AVIS-PRECED ,
            :V0AVIS-VLPRMLIQ ,
            :V0AVIS-VLPRMTOT ,
            :V0AVIS-SITCONTB ,
            :V0AVIS-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP ,
            :V0AVIS-ORIGAVISO:VIND-ORIGAVISO ,
            :V0AVIS-VALADT:VIND-VALADT)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0AVISOCRED VALUES ({FieldThreatment(this.V0AVIS_BCOAVISO)} , {FieldThreatment(this.V0AVIS_AGEAVISO)} , {FieldThreatment(this.V0AVIS_NRAVISO)} , {FieldThreatment(this.V0AVIS_NRSEQ)} , {FieldThreatment(this.V0AVIS_DTMOVTO)} , {FieldThreatment(this.V0AVIS_OPERACAO)} , {FieldThreatment(this.V0AVIS_TIPAVI)} , {FieldThreatment(this.V0AVIS_DTAVISO)} , {FieldThreatment(this.V0AVIS_VLIOCC)} , {FieldThreatment(this.V0AVIS_VLDESPES)} , {FieldThreatment(this.V0AVIS_PRECED)} , {FieldThreatment(this.V0AVIS_VLPRMLIQ)} , {FieldThreatment(this.V0AVIS_VLPRMTOT)} , {FieldThreatment(this.V0AVIS_SITCONTB)} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0AVIS_CODEMP))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_ORIGAVISO?.ToInt() == -1 ? null : this.V0AVIS_ORIGAVISO))} ,  {FieldThreatment((this.VIND_VALADT?.ToInt() == -1 ? null : this.V0AVIS_VALADT))})";

            return query;
        }
        public string V0AVIS_BCOAVISO { get; set; }
        public string V0AVIS_AGEAVISO { get; set; }
        public string V0AVIS_NRAVISO { get; set; }
        public string V0AVIS_NRSEQ { get; set; }
        public string V0AVIS_DTMOVTO { get; set; }
        public string V0AVIS_OPERACAO { get; set; }
        public string V0AVIS_TIPAVI { get; set; }
        public string V0AVIS_DTAVISO { get; set; }
        public string V0AVIS_VLIOCC { get; set; }
        public string V0AVIS_VLDESPES { get; set; }
        public string V0AVIS_PRECED { get; set; }
        public string V0AVIS_VLPRMLIQ { get; set; }
        public string V0AVIS_VLPRMTOT { get; set; }
        public string V0AVIS_SITCONTB { get; set; }
        public string V0AVIS_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }
        public string V0AVIS_ORIGAVISO { get; set; }
        public string VIND_ORIGAVISO { get; set; }
        public string V0AVIS_VALADT { get; set; }
        public string VIND_VALADT { get; set; }

        public static void Execute(R0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1 r0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1)
        {
            var ths = r0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0200_00_INSERT_AVISOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}