using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 : QueryBasis<R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FOLLOWUP
            VALUES (:V0MOVC-NUM-APOLICE
            ,:V0MOVC-NRENDOS
            ,:V0MOVC-NRPARCEL
            ,:V0FOLL-DACPARC
            ,:V0MOVC-DTMOVTO
            ,:V0FOLL-HORAOPER
            ,:V0MOVC-VALTIT
            ,:V0MOVC-BCOAVISO
            ,:V0MOVC-AGEAVISO
            ,:V0MOVC-NRAVISO
            ,:V0FOLL-CODBAIXA
            ,:V0FOLL-CDERRO01
            ,:V0FOLL-CDERRO02
            ,:V0FOLL-CDERRO03
            ,:V0FOLL-CDERRO04
            ,:V0FOLL-CDERRO05
            ,:V0FOLL-CDERRO06
            ,:V0FOLL-SITUACAO
            ,:V0FOLL-SITCONTB
            ,:V0FOLL-OPERACAO
            ,:V0FOLL-DTLIBER:VIND-DTLIBER
            ,:V0MOVC-DTQITBCO:VIND-DTQITBCO
            ,:V0FOLL-CODEMP:VIND-CODEMP
            , CURRENT TIMESTAMP
            ,:V0FOLL-ORDLIDER:VIND-ORDLIDER
            ,:V0FOLL-TIPSGU:VIND-TIPSGU
            ,:V0FOLL-APOLIDER:VIND-APOLIDER
            ,:V0FOLL-ENDOSLID:VIND-ENDOSLID
            ,:V0FOLL-CODLIDER:VIND-CODLIDER
            ,:V0FOLL-FONTE:VIND-FONTE
            ,:V0FOLL-NRRCAP:VIND-NRRCAP
            ,:V0MOVC-NOSSO-TITULO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FOLLOWUP VALUES ({FieldThreatment(this.V0MOVC_NUM_APOLICE)} ,{FieldThreatment(this.V0MOVC_NRENDOS)} ,{FieldThreatment(this.V0MOVC_NRPARCEL)} ,{FieldThreatment(this.V0FOLL_DACPARC)} ,{FieldThreatment(this.V0MOVC_DTMOVTO)} ,{FieldThreatment(this.V0FOLL_HORAOPER)} ,{FieldThreatment(this.V0MOVC_VALTIT)} ,{FieldThreatment(this.V0MOVC_BCOAVISO)} ,{FieldThreatment(this.V0MOVC_AGEAVISO)} ,{FieldThreatment(this.V0MOVC_NRAVISO)} ,{FieldThreatment(this.V0FOLL_CODBAIXA)} ,{FieldThreatment(this.V0FOLL_CDERRO01)} ,{FieldThreatment(this.V0FOLL_CDERRO02)} ,{FieldThreatment(this.V0FOLL_CDERRO03)} ,{FieldThreatment(this.V0FOLL_CDERRO04)} ,{FieldThreatment(this.V0FOLL_CDERRO05)} ,{FieldThreatment(this.V0FOLL_CDERRO06)} ,{FieldThreatment(this.V0FOLL_SITUACAO)} ,{FieldThreatment(this.V0FOLL_SITCONTB)} ,{FieldThreatment(this.V0FOLL_OPERACAO)} , {FieldThreatment((this.VIND_DTLIBER?.ToInt() == -1 ? null : this.V0FOLL_DTLIBER))} , {FieldThreatment((this.VIND_DTQITBCO?.ToInt() == -1 ? null : this.V0MOVC_DTQITBCO))} , {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.V0FOLL_CODEMP))} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_ORDLIDER?.ToInt() == -1 ? null : this.V0FOLL_ORDLIDER))} , {FieldThreatment((this.VIND_TIPSGU?.ToInt() == -1 ? null : this.V0FOLL_TIPSGU))} , {FieldThreatment((this.VIND_APOLIDER?.ToInt() == -1 ? null : this.V0FOLL_APOLIDER))} , {FieldThreatment((this.VIND_ENDOSLID?.ToInt() == -1 ? null : this.V0FOLL_ENDOSLID))} , {FieldThreatment((this.VIND_CODLIDER?.ToInt() == -1 ? null : this.V0FOLL_CODLIDER))} , {FieldThreatment((this.VIND_FONTE?.ToInt() == -1 ? null : this.V0FOLL_FONTE))} , {FieldThreatment((this.VIND_NRRCAP?.ToInt() == -1 ? null : this.V0FOLL_NRRCAP))} ,{FieldThreatment(this.V0MOVC_NOSSO_TITULO)})";

            return query;
        }
        public string V0MOVC_NUM_APOLICE { get; set; }
        public string V0MOVC_NRENDOS { get; set; }
        public string V0MOVC_NRPARCEL { get; set; }
        public string V0FOLL_DACPARC { get; set; }
        public string V0MOVC_DTMOVTO { get; set; }
        public string V0FOLL_HORAOPER { get; set; }
        public string V0MOVC_VALTIT { get; set; }
        public string V0MOVC_BCOAVISO { get; set; }
        public string V0MOVC_AGEAVISO { get; set; }
        public string V0MOVC_NRAVISO { get; set; }
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
        public string V0MOVC_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
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
        public string V0MOVC_NOSSO_TITULO { get; set; }

        public static void Execute(R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 r0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1)
        {
            var ths = r0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}