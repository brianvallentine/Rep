using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0005B
{
    public class R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1 : QueryBasis<R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_HISTPRE
            VALUES (:V0CHIS-COD-EMP ,
            :V0CHIS-CONGENER ,
            :V0CHIS-NUM-APOL ,
            :V0CHIS-NRENDOS ,
            :V0CHIS-NRPARCEL ,
            :V0CHIS-OCORHIST ,
            :V0CHIS-OPERACAO ,
            :V0CHIS-DTMOVTO ,
            :V0CHIS-TIPSGU ,
            :V0CHIS-PRM-TAR ,
            :V0CHIS-VAL-DESC ,
            :V0CHIS-VLPRMLIQ ,
            :V0CHIS-VLADIFRA ,
            :V0CHIS-VLCOMIS ,
            :V0CHIS-VLPRMTOT ,
            CURRENT TIMESTAMP,
            :V0CHIS-DTQITBCO:VIND-DAT-QTBC,
            :V0CHIS-SIT-FINANC:VIND-SIT-FINC,
            :V0CHIS-SIT-LIBRECUP:VIND-SIT-LIBR,
            :V0CHIS-NUMOCOR:VIND-NUM-OCOR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES ({FieldThreatment(this.V0CHIS_COD_EMP)} , {FieldThreatment(this.V0CHIS_CONGENER)} , {FieldThreatment(this.V0CHIS_NUM_APOL)} , {FieldThreatment(this.V0CHIS_NRENDOS)} , {FieldThreatment(this.V0CHIS_NRPARCEL)} , {FieldThreatment(this.V0CHIS_OCORHIST)} , {FieldThreatment(this.V0CHIS_OPERACAO)} , {FieldThreatment(this.V0CHIS_DTMOVTO)} , {FieldThreatment(this.V0CHIS_TIPSGU)} , {FieldThreatment(this.V0CHIS_PRM_TAR)} , {FieldThreatment(this.V0CHIS_VAL_DESC)} , {FieldThreatment(this.V0CHIS_VLPRMLIQ)} , {FieldThreatment(this.V0CHIS_VLADIFRA)} , {FieldThreatment(this.V0CHIS_VLCOMIS)} , {FieldThreatment(this.V0CHIS_VLPRMTOT)} , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DAT_QTBC?.ToInt() == -1 ? null : this.V0CHIS_DTQITBCO))},  {FieldThreatment((this.VIND_SIT_FINC?.ToInt() == -1 ? null : this.V0CHIS_SIT_FINANC))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V0CHIS_SIT_LIBRECUP))},  {FieldThreatment((this.VIND_NUM_OCOR?.ToInt() == -1 ? null : this.V0CHIS_NUMOCOR))})";

            return query;
        }
        public string V0CHIS_COD_EMP { get; set; }
        public string V0CHIS_CONGENER { get; set; }
        public string V0CHIS_NUM_APOL { get; set; }
        public string V0CHIS_NRENDOS { get; set; }
        public string V0CHIS_NRPARCEL { get; set; }
        public string V0CHIS_OCORHIST { get; set; }
        public string V0CHIS_OPERACAO { get; set; }
        public string V0CHIS_DTMOVTO { get; set; }
        public string V0CHIS_TIPSGU { get; set; }
        public string V0CHIS_PRM_TAR { get; set; }
        public string V0CHIS_VAL_DESC { get; set; }
        public string V0CHIS_VLPRMLIQ { get; set; }
        public string V0CHIS_VLADIFRA { get; set; }
        public string V0CHIS_VLCOMIS { get; set; }
        public string V0CHIS_VLPRMTOT { get; set; }
        public string V0CHIS_DTQITBCO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string V0CHIS_SIT_FINANC { get; set; }
        public string VIND_SIT_FINC { get; set; }
        public string V0CHIS_SIT_LIBRECUP { get; set; }
        public string VIND_SIT_LIBR { get; set; }
        public string V0CHIS_NUMOCOR { get; set; }
        public string VIND_NUM_OCOR { get; set; }

        public static void Execute(R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1 r1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1)
        {
            var ths = r1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1900_00_INSERT_V0COSEG_HSTPRM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}