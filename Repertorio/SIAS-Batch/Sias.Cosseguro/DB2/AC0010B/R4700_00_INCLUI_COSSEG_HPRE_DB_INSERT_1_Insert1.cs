using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1 : QueryBasis<R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_HISTPRE
            VALUES (:V2CHIS-COD-EMPR ,
            :V2CHIS-CONGENER ,
            :V2CHIS-NUM-APOL ,
            :V2CHIS-NRENDOS ,
            :V2CHIS-NRPARCEL ,
            :V2CHIS-OCORHIST ,
            :V2CHIS-OPERACAO ,
            :V2CHIS-DTMOVTO ,
            :V2CHIS-TIPSGU ,
            :V2CHIS-PRM-TAR ,
            :V2CHIS-VAL-DES ,
            :V2CHIS-VLPRMLIQ ,
            :V2CHIS-VLADIFRA ,
            :V2CHIS-VLCOMIS ,
            :V2CHIS-VLPRMTOT ,
            CURRENT TIMESTAMP ,
            :V2CHIS-DTQITBCO:VIND-DTQITBCO,
            :V2CHIS-SIT-FINANC:VIND-SIT-FINC,
            :V2CHIS-SIT-LIBREC:VIND-SIT-LIBR,
            :V2CHIS-NUM-OCOR:VIND-NUM-OCOR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES ({FieldThreatment(this.V2CHIS_COD_EMPR)} , {FieldThreatment(this.V2CHIS_CONGENER)} , {FieldThreatment(this.V2CHIS_NUM_APOL)} , {FieldThreatment(this.V2CHIS_NRENDOS)} , {FieldThreatment(this.V2CHIS_NRPARCEL)} , {FieldThreatment(this.V2CHIS_OCORHIST)} , {FieldThreatment(this.V2CHIS_OPERACAO)} , {FieldThreatment(this.V2CHIS_DTMOVTO)} , {FieldThreatment(this.V2CHIS_TIPSGU)} , {FieldThreatment(this.V2CHIS_PRM_TAR)} , {FieldThreatment(this.V2CHIS_VAL_DES)} , {FieldThreatment(this.V2CHIS_VLPRMLIQ)} , {FieldThreatment(this.V2CHIS_VLADIFRA)} , {FieldThreatment(this.V2CHIS_VLCOMIS)} , {FieldThreatment(this.V2CHIS_VLPRMTOT)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DTQITBCO?.ToInt() == -1 ? null : this.V2CHIS_DTQITBCO))},  {FieldThreatment((this.VIND_SIT_FINC?.ToInt() == -1 ? null : this.V2CHIS_SIT_FINANC))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V2CHIS_SIT_LIBREC))},  {FieldThreatment((this.VIND_NUM_OCOR?.ToInt() == -1 ? null : this.V2CHIS_NUM_OCOR))})";

            return query;
        }
        public string V2CHIS_COD_EMPR { get; set; }
        public string V2CHIS_CONGENER { get; set; }
        public string V2CHIS_NUM_APOL { get; set; }
        public string V2CHIS_NRENDOS { get; set; }
        public string V2CHIS_NRPARCEL { get; set; }
        public string V2CHIS_OCORHIST { get; set; }
        public string V2CHIS_OPERACAO { get; set; }
        public string V2CHIS_DTMOVTO { get; set; }
        public string V2CHIS_TIPSGU { get; set; }
        public string V2CHIS_PRM_TAR { get; set; }
        public string V2CHIS_VAL_DES { get; set; }
        public string V2CHIS_VLPRMLIQ { get; set; }
        public string V2CHIS_VLADIFRA { get; set; }
        public string V2CHIS_VLCOMIS { get; set; }
        public string V2CHIS_VLPRMTOT { get; set; }
        public string V2CHIS_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string V2CHIS_SIT_FINANC { get; set; }
        public string VIND_SIT_FINC { get; set; }
        public string V2CHIS_SIT_LIBREC { get; set; }
        public string VIND_SIT_LIBR { get; set; }
        public string V2CHIS_NUM_OCOR { get; set; }
        public string VIND_NUM_OCOR { get; set; }

        public static void Execute(R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1 r4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1)
        {
            var ths = r4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4700_00_INCLUI_COSSEG_HPRE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}