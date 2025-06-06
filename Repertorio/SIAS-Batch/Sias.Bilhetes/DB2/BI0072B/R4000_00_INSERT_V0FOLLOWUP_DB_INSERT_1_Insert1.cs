using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 : QueryBasis<R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FOLLOWUP
            VALUES (:V0FOLL-NUMAPOL ,
            :V0FOLL-NRENDOS ,
            :V0FOLL-NRPARCEL ,
            :V0FOLL-DACPARC ,
            :V0FOLL-DTMOVTO ,
            :V0FOLL-HORAOPER ,
            :V0FOLL-VLPREMIO ,
            :V0FOLL-BCOAVISO ,
            :V0FOLL-AGEAVISO ,
            :V0FOLL-NRAVISO ,
            :V0FOLL-CODBAIXA ,
            :V0FOLL-CDERRO01 ,
            :V0FOLL-CDERRO02 ,
            :V0FOLL-CDERRO03 ,
            :V0FOLL-CDERRO04 ,
            :V0FOLL-CDERRO05 ,
            :V0FOLL-CDERRO06 ,
            :V0FOLL-SITUACAO ,
            :V0FOLL-SITCONTB ,
            :V0FOLL-OPERACAO ,
            :V0FOLL-DTLIBER:VIND-DTLIBER ,
            :V0FOLL-DTQITBCO:VIND-DTQITBC ,
            :V0FOLL-CODEMP:VIND-CODEMP ,
            CURRENT TIMESTAMP ,
            :V0FOLL-ORDLIDER:VIND-ORDLIDER ,
            :V0FOLL-TIPSGU:VIND-TIPSGU ,
            :V0FOLL-APOLIDER:VIND-APOLIDER ,
            :V0FOLL-ENDOSLID:VIND-ENDOSLID ,
            :V0FOLL-CODLIDER:VIND-CODLIDER ,
            :V0FOLL-FONTE:VIND-FONTE ,
            :V0FOLL-NRRCAP:VIND-NRRCAP ,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FOLLOWUP VALUES ({FieldThreatment(this.V0FOLL_NUMAPOL)} , {FieldThreatment(this.V0FOLL_NRENDOS)} , {FieldThreatment(this.V0FOLL_NRPARCEL)} , {FieldThreatment(this.V0FOLL_DACPARC)} , {FieldThreatment(this.V0FOLL_DTMOVTO)} , {FieldThreatment(this.V0FOLL_HORAOPER)} , {FieldThreatment(this.V0FOLL_VLPREMIO)} , {FieldThreatment(this.V0FOLL_BCOAVISO)} , {FieldThreatment(this.V0FOLL_AGEAVISO)} , {FieldThreatment(this.V0FOLL_NRAVISO)} , {FieldThreatment(this.V0FOLL_CODBAIXA)} , {FieldThreatment(this.V0FOLL_CDERRO01)} , {FieldThreatment(this.V0FOLL_CDERRO02)} , {FieldThreatment(this.V0FOLL_CDERRO03)} , {FieldThreatment(this.V0FOLL_CDERRO04)} , {FieldThreatment(this.V0FOLL_CDERRO05)} , {FieldThreatment(this.V0FOLL_CDERRO06)} , {FieldThreatment(this.V0FOLL_SITUACAO)} , {FieldThreatment(this.V0FOLL_SITCONTB)} , {FieldThreatment(this.V0FOLL_OPERACAO)} ,  {FieldThreatment((this.VIND_DTLIBER?.ToInt() == -1 ? null : this.V0FOLL_DTLIBER))} ,  {FieldThreatment((this.VIND_DTQITBC?.ToInt() == -1 ? null : this.V0FOLL_DTQITBCO))} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0FOLL_CODEMP))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_ORDLIDER?.ToInt() == -1 ? null : this.V0FOLL_ORDLIDER))} ,  {FieldThreatment((this.VIND_TIPSGU?.ToInt() == -1 ? null : this.V0FOLL_TIPSGU))} ,  {FieldThreatment((this.VIND_APOLIDER?.ToInt() == -1 ? null : this.V0FOLL_APOLIDER))} ,  {FieldThreatment((this.VIND_ENDOSLID?.ToInt() == -1 ? null : this.V0FOLL_ENDOSLID))} ,  {FieldThreatment((this.VIND_CODLIDER?.ToInt() == -1 ? null : this.V0FOLL_CODLIDER))} ,  {FieldThreatment((this.VIND_FONTE?.ToInt() == -1 ? null : this.V0FOLL_FONTE))} ,  {FieldThreatment((this.VIND_NRRCAP?.ToInt() == -1 ? null : this.V0FOLL_NRRCAP))} , 0)";

            return query;
        }
        public string V0FOLL_NUMAPOL { get; set; }
        public string V0FOLL_NRENDOS { get; set; }
        public string V0FOLL_NRPARCEL { get; set; }
        public string V0FOLL_DACPARC { get; set; }
        public string V0FOLL_DTMOVTO { get; set; }
        public string V0FOLL_HORAOPER { get; set; }
        public string V0FOLL_VLPREMIO { get; set; }
        public string V0FOLL_BCOAVISO { get; set; }
        public string V0FOLL_AGEAVISO { get; set; }
        public string V0FOLL_NRAVISO { get; set; }
        public string V0FOLL_CODBAIXA { get; set; }
        public string V0FOLL_CDERRO01 { get; set; }
        public string V0FOLL_CDERRO02 { get; set; }
        public string V0FOLL_CDERRO03 { get; set; }
        public string V0FOLL_CDERRO04 { get; set; }
        public string V0FOLL_CDERRO05 { get; set; }
        public string V0FOLL_CDERRO06 { get; set; }
        public string V0FOLL_SITUACAO { get; set; }
        public string V0FOLL_SITCONTB { get; set; }
        public string V0FOLL_OPERACAO { get; set; }
        public string V0FOLL_DTLIBER { get; set; }
        public string VIND_DTLIBER { get; set; }
        public string V0FOLL_DTQITBCO { get; set; }
        public string VIND_DTQITBC { get; set; }
        public string V0FOLL_CODEMP { get; set; }
        public string VIND_CODEMP { get; set; }
        public string V0FOLL_ORDLIDER { get; set; }
        public string VIND_ORDLIDER { get; set; }
        public string V0FOLL_TIPSGU { get; set; }
        public string VIND_TIPSGU { get; set; }
        public string V0FOLL_APOLIDER { get; set; }
        public string VIND_APOLIDER { get; set; }
        public string V0FOLL_ENDOSLID { get; set; }
        public string VIND_ENDOSLID { get; set; }
        public string V0FOLL_CODLIDER { get; set; }
        public string VIND_CODLIDER { get; set; }
        public string V0FOLL_FONTE { get; set; }
        public string VIND_FONTE { get; set; }
        public string V0FOLL_NRRCAP { get; set; }
        public string VIND_NRRCAP { get; set; }

        public static void Execute(R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 r4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1)
        {
            var ths = r4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}